using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UISkinButton : UISkin
{
    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning,
        Text
    }

    [SerializeField] ButtonType _buttonType;

    Image _image;
    Button _button;

    public override void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();

        base.Awake();
    }

    protected override void OnSkinUI()
    {
        _button.transition = Selectable.Transition.SpriteSwap;
        _button.targetGraphic = _image;

        _image.sprite = SkinData.ButtonSprite;
        _image.type = Image.Type.Sliced;
        _button.spriteState = SkinData.ButtonSpriteState;

        switch (_buttonType)
        {
            case ButtonType.Confirm:
                _image.color = SkinData.ConfirmColor;
                break;

            case ButtonType.Decline:
                _image.color = SkinData.DeclineColor;
                break;
            //
            case ButtonType.Default:
                _image.color = SkinData.DefaultColor;
                break;
            //
            case ButtonType.Warning:
                _image.color = SkinData.WarningColor;
                break;
            case ButtonType.Text:
                _image.color = SkinData.ButtonTextColor;
                break;
        }

        base.OnSkinUI();
    }
}
