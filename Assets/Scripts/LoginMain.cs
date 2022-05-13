using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LoginMain : MonoBehaviour
{
    [SerializeField] InputField _emailRegister, _passwordRegister, _usernameRegister, _repeatPasswordRegister;
    [SerializeField] InputField _passwordLogin, _usernameAndEmailLogin;
    [SerializeField] Toggle _rememberToggle;
    [SerializeField] Button _registerOrLogin;
    [Header ("Guest Login Settings")]
    [SerializeField] bool _guestLogin;
    [SerializeField] GameObject _emailRegisterGO, _passwordRegisterGO, _usernameRegisterGO, _repeatPasswordRegisterGO, _passwordLoginGO, _usernameAndEmailLoginGO;
    [SerializeField] Text _registerOrLoginText;

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
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest() { Username = _usernameRegister.text, Email = _emailRegister.text, Password = _passwordRegister.text }, Result => { Debug.Log("Kayıt Başarılı"); }, Error => { Debug.Log("Kayıt Başarısız!"); });
    }

    public void RememberMe()
    {
        if (_rememberToggle.isOn)
        {
            PlayerPrefs.SetString("emailOrUsername", _usernameAndEmailLogin.text);
            PlayerPrefs.SetString("password", _passwordLogin.text);
        }
    }

    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() { CreateAccount = _guestLogin }, Result => { }, Error => { });
    }

    public void SwitchLoginOrRegister()
    {
        switch (_emailRegisterGO.activeInHierarchy)
        {
            case true:
                _usernameAndEmailLoginGO.SetActive(false);
                _passwordLoginGO.SetActive(false);
                _emailRegisterGO.SetActive(true);
                _passwordRegisterGO.SetActive(true);
                _repeatPasswordRegisterGO.SetActive(true);
                _usernameRegisterGO.SetActive(true);
                _registerOrLoginText.text = "Register";
                break;

            default:
                _usernameAndEmailLoginGO.SetActive(true);
                _passwordLoginGO.SetActive(true);
                _emailRegisterGO.SetActive(false);
                _passwordRegisterGO.SetActive(false);
                _repeatPasswordRegisterGO.SetActive(false);
                _usernameRegisterGO.SetActive(false);
                _registerOrLoginText.text = "Login";
                break;
        }
    }

}
