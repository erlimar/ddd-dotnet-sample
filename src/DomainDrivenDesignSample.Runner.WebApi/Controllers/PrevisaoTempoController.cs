// Copyright (c) Time DomainDrivenDesignSample. Todos os direitos reservados.
// Este arquivo é parte do projeto DomainDrivenDesignSample.

using System.ComponentModel;

using DomainDrivenDesignSample.Runner.WebApi.Presenters;

namespace DomainDrivenDesignSample.Runner.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[DisplayName("Previsão do tempo")]
public class PrevisaoTempoController : ControllerBase
{
    private static readonly Action<ILogger, Exception> _enterInGetPrevisaoTempoAction = LoggerMessage.Define(
        LogLevel.Trace,
        new EventId(1, "EnterInGetPrevisaoTempoAction"),
        "Enter in GetPrevisaoTempo");

    private static readonly string[] Summaries = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    private readonly ILogger<PrevisaoTempoController> _logger;

    public PrevisaoTempoController(ILogger<PrevisaoTempoController> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet(Name = "GetPrevisaoTempo")]
    public IEnumerable<PrevisaoTempoViewModel> Get()
    {
        _enterInGetPrevisaoTempoAction(_logger, default!);

        return Enumerable.Range(1, 5)
            .Select(index => new PrevisaoTempoViewModel
            {
                Data = DateTime.Now.AddDays(index),
                TemperaturaC = Random.Shared.Next(-20, 55),
                Resumo = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}