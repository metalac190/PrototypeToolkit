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
        Default = 0,
        Confirm,
        Decline,
    }

    [SerializeField] ButtonType _buttonType;

    protected override void OnSkinUI(UISkinData skinData)
    {
        Image _image = GetComponent<Image>();
        Button _button = GetComponent<Button>();

        _button.transition = Selectable.Transition.SpriteSwap;
        _button.targetGraphic = _image;

        _image.sprite = skinData.ButtonSprite;
        _image.type = Image.Type.Sliced;
        _button.spriteState = skinData.ButtonSpriteState;

        switch (_buttonType)
        {
            case ButtonType.Default:
                _image.color = skinData.DefaultColor;
                break;

            case ButtonType.Confirm:
                _image.color = skinData.ConfirmColor;
                break;

            case ButtonType.Decline:
                _image.color = skinData.DeclineColor;
                break;
            //

        }

    }

}
