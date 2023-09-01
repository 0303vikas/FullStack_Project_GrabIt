export interface UserType {
  id: string
  firstName: string
  lastName: string
  role: string
  email: string
  password: string
  imageURL: string
}

export interface UserLoginType {
  email: string
  password: string
}
