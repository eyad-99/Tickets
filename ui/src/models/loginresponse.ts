export class Loginresponse {
    email: string;
  roles: string[];
  token: string;

  constructor(email: string, roles: string[], token: string) {
    this.email = email;
    this.roles = roles;
    this.token = token;
  }
}
