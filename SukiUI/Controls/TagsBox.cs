using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;

namespace SukiUI.Controls;

public class TagsBox : Avalonia.Controls.TextBox
{
    private TextBox? _text;
    public delegate void KeyPressedEventHandler(object sender, Key? key);
    public static event KeyPressedEventHandler? KeyPressed;

    public delegate void TextInputEventHandler(object sender, string? text);
    public static event TextInputEventHandler? TextInputHandler;

    public delegate void TextChangedEventHandler(object sender, string? text);
    public static event TextChangedEventHandler? TextChangedHandler;

    public TagsBox()
    {
        AddHandler(KeyDownEvent, EnterTextBoxTags, RoutingStrategies.Tunnel);
        AddHandler(TextInputEvent, OnTextInput, RoutingStrategies.Tunnel);
        this.GetObservable(TextBox.TextProperty).Subscribe(text => OnTextChanged(this, text));
    }

    private void OnTextChanged(object sender, string? text)
    {
        TextChangedHandler?.Invoke(this, text);
    }

    private void EnterTextBoxTags(object? sender, KeyEventArgs e)
    {
        KeyPressed?.Invoke(this, e.Key);
    }

    private void OnTextInput(object? sender, TextInputEventArgs e)
    {
        TextInputHandler?.Invoke(this, e.Text);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);       
    }
}