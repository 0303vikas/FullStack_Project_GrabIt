import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import axios, { AxiosError } from "axios"

import { UserLoginType, UserType } from "../../types/User"
import { NewUserType } from "../../types/NewUser"
import { ErrorMessageType } from "../../types/ErrorType"

const initialState: {
  users: UserType[]
  loading: boolean
  authloading: boolean
  error: ErrorMessageType
  currentUser?: UserType
  imageString?: string
} = {
  users: [],
  loading: false,
  error: {
    message: "",
    statusCode: 200,
  },
  authloading: true,
}

export const fetchAllUsers = createAsyncThunk("fetchAllUsers", async () => {
  try {
    const request = await axios.get<UserType[]>(
      `${process.env.REACT_APP_URL}/api/v1/users`,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("userToken")}`,
          "Content-Type": "application/json",
        },
      }
    )
    return request.data
  } catch (e) {
    const error = e as AxiosError
    return error
  }
})

export const createUser = createAsyncThunk(
  "createUser",
  async (user: NewUserType, { dispatch }) => {
    try {
      const request = await axios.post<UserType>(
        `${process.env.REACT_APP_URL}/api/v1/users`,
        user
      )

      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const createAdminUser = createAsyncThunk(
  "createAdminUser",
  async (userData: NewUserType) => {
    try {
      const request = await axios.post<UserType>(
        `${process.env.REACT_APP_URL}/api/v1/users/createadmin`,
        userData,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
            "Content-Type": "application/json",
          },
        }
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const updatePassword = createAsyncThunk(
  "updatePassword",
  async (data: { id: string; password: string }) => {
    try {
      const request = await axios.put<UserType>(
        `${process.env.REACT_APP_URL}/api/v1/users/updatepassword/${data.id}`,
        data.password,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
            "Content-Type": "application/json",
          },
        }
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const updateUser = createAsyncThunk(
  "updateUser",
  async (user: { id: string; updateData: Partial<UserType> }) => {
    try {
      const request = await axios.put<UserType>(
        `${process.env.REACT_APP_URL}/api/v1/users/${user.id}`,
        user.updateData,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
            "Content-Type": "application/json",
          },
        }
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const deleteUser = createAsyncThunk("deleteUser", async (id: string) => {
  try {
    const request = await axios.delete<boolean>(
      `${process.env.REACT_APP_URL}/api/v1/users/${id}`,
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("userToken")}`,
          "Content-Type": "application/json",
        },
      }
    )
    return { response: request.data, id: id }
  } catch (e) {
    const error = e as AxiosError
    return error
  }
})

export const authenticateUser = createAsyncThunk(
  "authentication",
  async (token: string) => {
    try {
      const request = await axios.get<UserType>(
        `${process.env.REACT_APP_URL}/api/v1/auth/profile`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const loginUser = createAsyncThunk(
  "login",
  async ({ email, password }: UserLoginType, { dispatch }) => {
    try {
      const request = await axios.post<string>(
        `${process.env.REACT_APP_URL}/api/v1/auth/login`,
        { email, password }
      )
      localStorage.setItem("userToken", request.data)
      const authentication = await dispatch(authenticateUser(request.data))
      return authentication.payload as UserType
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

const userSlice = createSlice({
  name: "user",
  initialState: initialState,
  reducers: {
    createUserLocally: (state, action: PayloadAction<UserType>) => {
      state.users.push(action.payload)
    },
    clearUserError: (state) => {
      state.error = initialState.error
    },
    clearUserLogin: (state) => {
      state.currentUser = initialState.currentUser
      state.error = initialState.error
      state.authloading = false
    },
    clearAllUsers: (state) => {
      return initialState
    },
    findOneUser: (state) => {},
  },
  extraReducers: (build) => {
    build
      .addCase(fetchAllUsers.pending, (state, action) => {
        state.loading = true
      })
      .addCase(fetchAllUsers.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            statusCode: action.payload.response?.data
              ? action.payload.response.data
              : 500,
            message: action.payload.response?.status
              ? action.payload.response.data
              : "Server Error occured during fetching user.",
          } as ErrorMessageType
        } else {
          state.users = action.payload
        }
        state.loading = false
      })
      .addCase(fetchAllUsers.rejected, (state, action) => {
        state.error = { message: "Cannot fetch data", statusCode: 500 }
      })
      .addCase(createUser.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            statusCode: action.payload.response?.data
              ? action.payload.response.data
              : 500,
            message: action.payload.response?.status
              ? action.payload.response.data
              : "Server Error occured during creating user.",
          } as ErrorMessageType
        } else {
          state.users.push(action.payload)
        }
      })
      .addCase(createUser.rejected, (state, action) => {
        state.error = {
          message: "Server Error occured during creating new user",
          statusCode: 500,
        }
      })
      .addCase(updateUser.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            statusCode: action.payload.response?.data
              ? action.payload.response.data
              : 500,
            message: action.payload.response?.status
              ? action.payload.response.data
              : "Server Error occured during updating user.",
          } as ErrorMessageType
        } else {
          state.currentUser = action.payload
        }
      })
      .addCase(updateUser.rejected, (state, action) => {
        state.error = {
          message: "Server Error occured during updating the user.",
          statusCode: 500,
        }
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            statusCode: action.payload.response?.data
              ? action.payload.response.data
              : 500,
            message: action.payload.response?.status
              ? action.payload.response.data
              : "Server Error occured during loggin.",
          } as ErrorMessageType
        } else {
          state.currentUser = action.payload
        }
        state.loading = false
        state.authloading = true
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.error = {
          message: "Server Error occured during loggin.",
          statusCode: 500,
        }
      })
      .addCase(updatePassword.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            statusCode: action.payload.response?.data
              ? action.payload.response.data
              : 500,
            message: action.payload.response?.status
              ? action.payload.response.data
              : "Server Error occured during updating password.",
          } as ErrorMessageType
        } else {
          state.currentUser = action.payload
        }
        state.loading = false
      })
      .addCase(updatePassword.rejected, (state, action) => {
        state.error = {
          message: "Server Error occured during updating password.",
          statusCode: 500,
        } as ErrorMessageType
      })
      .addCase(authenticateUser.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            statusCode: action.payload.response?.data
              ? action.payload.response.data
              : 500,
            message: action.payload.response?.status
              ? action.payload.response.data
              : "Server Error occured during authenticating user.",
          } as ErrorMessageType
          localStorage.removeItem("userToken")
          clearUserLogin()
        } else {
          state.currentUser = action.payload
        }
        state.authloading = false
      })
      .addCase(authenticateUser.pending, (state) => {
        state.authloading = true
      })
      .addCase(authenticateUser.rejected, (state, action) => {
        state.error = {
          message: "Server Error occured during authentication",
          statusCode: 500,
        }
      })
  },
})

const userReducer = userSlice.reducer
export const {
  clearAllUsers,
  createUserLocally,
  clearUserLogin,
  clearUserError,
} = userSlice.actions
export default userReducer
