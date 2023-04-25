using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindController : MonoBehaviour
{
    public GameObject[] ControllerButtons;
    public GameObject[] KeyboardButtons;
    private C_PlayerController Player;

    [SerializeField] private InputActionAsset actions;
    [SerializeField] private InputActionReference[] player;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    private void Start()
    {
        Player = FindObjectOfType<C_PlayerController>();
        if (PlayerPrefs.GetString("rebinds") == null)
            PlayerPrefs.SetString("rebinds", string.Empty);
        int x = 0;
        foreach (GameObject button in ControllerButtons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = InputControlPath.ToHumanReadableString(
            player[x].action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            x++;
        }
        x = 0;
        foreach (GameObject button2 in KeyboardButtons)
        {
            button2.GetComponentInChildren<TextMeshProUGUI>().text = InputControlPath.ToHumanReadableString(
            player[x].action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
            x++;
        }

    }
    public void ButtonKeyB(int buttonNumber)
    {
        KeyboardButtons[buttonNumber].GetComponentInChildren<TextMeshProUGUI>().text = "...";

        player[buttonNumber].action.Disable();

        rebindingOperation = player[buttonNumber].action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>/press")
            .WithControlsExcluding("<Pointer>/position")
            .WithControlsExcluding("<Gamepad>")
            .WithTargetBinding(0)
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => rebindCompleteKeyB(buttonNumber, 0))
            .Start();
        if(Player != null)
        {
            Player.UpdateControls();
        }
    }
    public void ButtonCtrl(int buttonNumber)
    {
        ControllerButtons[buttonNumber].GetComponentInChildren<TextMeshProUGUI>().text = "...";

        player[buttonNumber].action.Disable();

        rebindingOperation = player[buttonNumber].action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>/press")
            .WithControlsExcluding("<Pointer>/position")
            .WithControlsExcluding("<Keyboard>")
            .WithTargetBinding(1)
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => rebindCompleteCtrl(buttonNumber, 1))
            .Start();
        if(Player != null)
        {
            Player.UpdateControls();
        }
    }
    private void rebindCompleteCtrl(int buttonNumber, int binding)
    {
        rebindingOperation.Dispose();
        player[buttonNumber].action.Enable();
        InputBinding inputBinding = player[buttonNumber].action.bindings[binding];
        actions.FindAction(player[buttonNumber].action.name).ApplyBindingOverride(binding, inputBinding);
        var rebinds = actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString("rebinds", rebinds);

        ControllerButtons[buttonNumber].GetComponentInChildren<TextMeshProUGUI>().text = InputControlPath.ToHumanReadableString(
            player[buttonNumber].action.bindings[binding].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        //FindObjectOfType<C_PlayerController>().UpdateControls();
        if (Player != null)
        {
            Player.UpdateControls();
        }
    }
    private void rebindCompleteKeyB(int buttonNumber, int binding)
    {
        rebindingOperation.Dispose();
        player[buttonNumber].action.Enable();
        InputBinding inputBinding = player[buttonNumber].action.bindings[binding];
        actions.FindAction(player[buttonNumber].action.name).ApplyBindingOverride(binding, inputBinding);
        var rebinds = actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString("rebinds", rebinds);

        KeyboardButtons[buttonNumber].GetComponentInChildren<TextMeshProUGUI>().text = InputControlPath.ToHumanReadableString(
            player[buttonNumber].action.bindings[binding].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
        //FindObjectOfType<C_PlayerController>().UpdateControls();
        if (Player != null)
        {
            Player.UpdateControls();
        }
    }
}
