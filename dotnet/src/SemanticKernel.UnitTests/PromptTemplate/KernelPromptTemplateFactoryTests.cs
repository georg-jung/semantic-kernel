﻿// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;
using Xunit;

namespace SemanticKernel.UnitTests.PromptTemplate;

public sealed class KernelPromptTemplateFactoryTests
{
    [Fact]
    public void ItCreatesBasicPromptTemplateByDefault()
    {
        // Arrange
        var templateString = "{{$input}}";
        var target = new KernelPromptTemplateFactory();

        // Act
        var result = target.Create(templateString, new PromptTemplateConfig());

        // Assert
        Assert.NotNull(result);
        Assert.True(result is KernelPromptTemplate);
    }

    [Fact]
    public void ItCreatesBasicPromptTemplate()
    {
        // Arrange
        var templateString = "{{$input}}";
        var target = new KernelPromptTemplateFactory();

        // Act
        var result = target.Create(templateString, new PromptTemplateConfig() { TemplateFormat = "semantic-kernel" });

        // Assert
        Assert.NotNull(result);
        Assert.True(result is KernelPromptTemplate);
    }

    [Fact]
    public void ItThrowsExceptionForUnknowPromptTemplateFormat()
    {
        // Arrange
        var templateString = "{{$input}}";
        var target = new KernelPromptTemplateFactory();

        // Act
        // Assert
        Assert.Throws<KernelException>(() => target.Create(templateString, new PromptTemplateConfig() { TemplateFormat = "unknown-format" }));
    }
}
