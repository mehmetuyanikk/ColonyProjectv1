using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LoginMain : MonoBehaviour
{
    #region RegisterLogin System
    [SerializeField] InputField _emailRegister, _passwordRegister, _usernameRegister, _repeatPasswordRegister;
    [SerializeField] InputField _passwordLogin, _usernameAndEmailLogin;
    [SerializeField] Button _registerButton, _loginButton;
    [SerializeField] Text _resultText;
    [Header("Guest Login Settings")]
    [SerializeField] bool _guestLogin = true;
    [SerializeField] GameObject _registerPanel, _loginPanel;

    [SerializeField] Animator _animator;

    private void Awake()
    {
        SwitchLoginOrRegister();
    }

    void LoginEmail()
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest() { Email = _usernameAndEmailLogin.text, Password = _passwordLogin.text }, Result => { Debug.Log("Giriş Başarılı"); }, Error => { Debug.Log("Giriş Başarısız!"); });
    }

    void LoginUserName()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest() { Username = _usernameAndEmailLogin.text, Password = _passwordLogin.text }, Result => { Debug.Log("Giriş Başarılı"); }, Error => { Debug.Log("Giriş Başarısız"); });
    }

    public void SwitchLoginType()
    {
        if (_usernameAndEmailLogin.text.IndexOf('@') > 0)

            LoginEmail();

        else LoginUserName();

    }

    public void Register()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest() { Username = _usernameRegister.text, Email = _emailRegister.text, Password = _passwordRegister.text }, Result => { _animator.Play("Success"); }, Error => { _animator.Play("Error"); _animator.Play("Fail"); });
    }

    public void RememberMe()
    {
        
            PlayerPrefs.SetString("emailOrUsername", _usernameAndEmailLogin.text);
            PlayerPrefs.SetString("password", _passwordLogin.text);
        
    }

    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() { CreateAccount = _guestLogin, AndroidDeviceId = SystemInfo.deviceUniqueIdentifier }, Result => { Debug.Log("Başarılı"); }, Error => { Debug.Log("Başarısız"); });
    }

    public void SwitchLoginOrRegister()
    {
        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;

            default:
                _loginPanel.SetActive(false);
                _registerPanel.SetActive(true);
                break;
        }
    } 
    #endregion

}
