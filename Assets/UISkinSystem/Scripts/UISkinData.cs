using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UI/UISkin", fileName = "UISkin_")]
public class UISkinData : ScriptableObject
{
    [Header("Button Skin")]
    [SerializeField] Color _buttonTextColor = Color.white;

    [SerializeField] Sprite _buttonSprite;
    [SerializeField] SpriteState _buttonSpriteState;

    [SerializeField] Color _defaultColor = Color.blue;
    [SerializeField] Sprite _defaultIcon;

    [SerializeField] Color _confirmColor = Color.green;
    [SerializeField] Sprite _confirmIcon;

    [SerializeField] Color _declineColor = Color.red;
    [SerializeField] Sprite _declineIcon;

    [SerializeField] Color _warningColor = Color.yellow;
    [SerializeField] Sprite _warningIcon;

    [Header("Text")]
    [SerializeField] Color _headerTextColor = Color.white;
    [SerializeField] Color _bodyTextCOlor = Color.white;

    [Header("Window")]
    [SerializeField] Color _panelColor = Color.gray;
    [SerializeField] Color _headerBackgroundColor = Color.gray;
    [SerializeField] Color _bodyBackgroundColor = Color.gray;
    [SerializeField] Color _footerBackgroundColor = Color.gray;

    public Color ButtonTextColor => _buttonTextColor;

    public Sprite ButtonSprite => _buttonSprite;
    public SpriteState ButtonSpriteState => _buttonSpriteState;

    public Color DefaultColor => _defaultColor;
    public Sprite DefaultIcon => _defaultIcon;

    public Color ConfirmColor => _confirmColor;
    public Sprite ConfirmIcon => _confirmIcon;

    public Color DeclineColor => _declineColor;
    public Sprite DeclineIcon => _declineIcon;

    public Color WarningColor => _warningColor;
    public Sprite WarningIcon => _warningIcon;


}
