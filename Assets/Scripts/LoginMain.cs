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
    [Header ("Guest Login Settings")]
    [SerializeField] bool _guestLogin;

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

    }

    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest() { CreateAccount = _guestLogin }, Result => { }, Error => { });
    }

}
