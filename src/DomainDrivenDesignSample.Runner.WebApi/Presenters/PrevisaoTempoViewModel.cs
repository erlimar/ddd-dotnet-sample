// Copyright (c) Time DomainDrivenDesignSample. Todos os direitos reservados.
// Este arquivo é parte do projeto DomainDrivenDesignSample.

using System.ComponentModel;

namespace DomainDrivenDesignSample.Runner.WebApi.Presenters;

/// <summary>
/// Dados de previsão do tempo
/// </summary>
[DisplayName("PrevisaoTempo")]
public class PrevisaoTempoViewModel
{
    /// <summary>
    /// Data da previsão
    /// </summary>
    public DateTime Data { get; set; }

    /// <summary>
    /// Temperatura em Celsius
    /// </summary>
    public int TemperaturaC { get; set; }

    /// <summary>
    /// Temperatura em Fahrenheit
    /// </summary>
    public int TemperaturaF => 32 + (int)(TemperaturaC / 0.5556);

    /// <summary>
    /// Texto com resumo da previsão
    /// </summary>
    public string? Resumo { get; set; }
}