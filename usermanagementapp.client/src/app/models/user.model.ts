export interface Contact {
  id: number;
  phone: string;
  address: string;
  city: string;
  country: string;
}

export interface Role {
  id: number;
  name: string;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  active: boolean;
  company: string;
  sex: string;
  contact: Contact;
  role: Role;
}
