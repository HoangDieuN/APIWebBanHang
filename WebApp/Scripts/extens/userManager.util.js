const userManagerConfig = {
    client_id: "218178c8-3ef5-459f-a5ab-ce124ccba916",
    client_secret: "eb78366a-b9ae-4325-91d6-5a1dff8d4fa2",
    redirect_uri: `${window.location.protocol}//${window.location.hostname}${window.location.port ? `:${window.location.port}` : ''}/signin-oidc`,
    post_logout_redirect_uri: `${window.location.protocol}//${window.location.hostname}${window.location.port ? `:${window.location.port}` : ''}`,
    response_type: "code",
    scope: "openid profile api1",
    authority: "https://sso.dhktyduocdn.edu.vn",
    filterProtocolClaims: true,
    loadUserInfo: true,
};

const userManager = new Oidc.UserManager(userManagerConfig);

const logout = () => {
    userManager.getUser().then(user => {
        userManager.signoutRedirect({ id_token_hint: user?.id_token });
        $.get("/Account/SignedOut");
    })
}

const login = () => {
    userManager.getUser().then(user => {
        if (!user)
            userManager.signinRedirect();
    })
}

const loginCallback = () => {
    userManager.signinRedirectCallback()
        .then(user =>
            window.location = "/Account/SignIn?sub=" + user.profile.sub
        )
        .catch(error => console.log(error));
}