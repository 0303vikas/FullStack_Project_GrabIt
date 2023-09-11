import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"

import { AddressType } from "../../types/Address"
import { ErrorMessageType } from "../../types/ErrorType"
import axios, { AxiosError } from "axios"
import { CreateAddressType } from "../../types/CreateAddress"

const initialState: {
  address: AddressType[]
  loading: boolean
  error: ErrorMessageType
} = {
  address: [],
  loading: false,
  error: {
    message: "",
    statusCode: 200,
  },
}

export const fetchAllUserAddress = createAsyncThunk(
  "getAllUserAddress",
  async (id: string) => {
    try {
      const request = await axios.get<AddressType[]>(
        `${process.env.REACT_APP_URL}/api/v1/users/${id}/addresses`,
        {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("userToken")}`,
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

export const createAddress = createAsyncThunk(
  "createAddress",
  async (address: CreateAddressType) => {
    try {
      const request = await axios.post(
        `${process.env.REACT_APP_URL}/api/v1/addresss`,
        address,
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

export const deleteAddress = createAsyncThunk(
  "deleteAddress",
  async (id: string) => {
    try {
      const request = await axios.delete(
        `${process.env.REACT_APP_URL}/api/v1/addresss/${id}`,
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

export const updateOneAddress = createAsyncThunk(
  "updateOneAddress",
  async ({ id, address }: { id: string; address: Omit<AddressType, "id"> }) => {
    try {
      const request = await axios.put(
        `${process.env.REACT_APP_URL}/api/v1/addresss/${id}`,
        address,
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

const addressSlice = createSlice({
  name: "address",
  initialState: initialState,
  reducers: {
    clearAddressStore: (state) => {
      return initialState
    },
    clearAddressError: (state) => {
      state.error = initialState.error
    },
  },
  extraReducers: (build) => {
    build
      .addCase(fetchAllUserAddress.pending, (state) => {
        state.loading = true
      })
      .addCase(fetchAllUserAddress.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during fetching user addresses.",
            statusCode: action.payload.response?.status,
          }
        } else {
          state.address = action.payload
        }
        state.loading = false
      })
      .addCase(fetchAllUserAddress.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message ||
            "Internal Server Error during fetching user addresses.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(createAddress.pending, (state) => {
        state.loading = true
      })
      .addCase(createAddress.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during creating address.",
            statusCode: action.payload.response?.status,
          }
        } else {
          state.address.push(action.payload)
        }
        state.loading = false
      })
      .addCase(createAddress.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message ||
            "Internal Server Error during creating address.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(deleteAddress.pending, (state) => {
        state.loading = true
      })
      .addCase(deleteAddress.fulfilled, (state, action) => {
        if (action.payload.response === "No Content") {
          const response = action.payload
          const updatedArray = state.address.filter(
            (item) => item.id !== response.id
          )
          state.address = updatedArray
        } else {
          state.error = {
            message: "Delete request failed.",
            statusCode: 500,
          }
        }
        state.loading = false
      })
      .addCase(deleteAddress.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message ||
            "Internal Server Error during deleting address.",
          statusCode: 500,
        }
        state.loading = false
      })
      .addCase(updateOneAddress.pending, (state) => {
        state.loading = true
      })
      .addCase(updateOneAddress.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = {
            message:
              action.payload.response?.statusText ||
              "Internal Server Error during updating address.",
            statusCode: action.payload.response?.status,
          }
        } else {
          const newitem = action.payload
          const address = state.address.map((item) => {
            if (newitem.id === item.id) {
              return { ...item, ...newitem }
            }
            return item
          })
          return {
            ...state,
            address,
          }
        }
        state.loading = false
      })
      .addCase(updateOneAddress.rejected, (state, action) => {
        state.error = {
          message:
            action.error.message ||
            "Internal Server Error during updating address.",
          statusCode: 500,
        }
        state.loading = false
      })
  },
})

const addressReducer = addressSlice.reducer
export const { clearAddressStore, clearAddressError } = addressSlice.actions
export default addressReducer
