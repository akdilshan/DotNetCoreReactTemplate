import { WebStorageStateStore  } from 'oidc-client';
export default {
    authority: 'https://localhost:5443',
    client_id: 'interactive',
    redirect_uri: 'http://localhost:3000/signin-oidc',
    response_type: 'code',
    scope: 'openid profile',
    post_logout_redirect_uri: 'http://localhost:3000',
    automaticSilentRenew: true,
    loadUserInfo: true,
    revokeAccessTokenOnSignout: true,
    userStore: new WebStorageStateStore({ store: window.localStorage }),
  };