import { UserManager, WebStorageStateStore  } from 'oidc-client';
import config from '../config';

const userManager = new UserManager(config);

export default userManager;