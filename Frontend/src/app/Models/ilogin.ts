export interface ILogin {
 email?: string; 
 password?: string;
 RememberMe?: boolean;
 token?: string;
 expires?: Date;
 userId?:string;
 refreshToken?:string;
 refreshTokenExpiresOn?:Date;
 roles?:string[];
}
