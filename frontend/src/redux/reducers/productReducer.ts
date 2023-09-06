import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import axios, { AxiosError } from "axios"

import { ProductType } from "../../types/Product"
import { NewProductType } from "../../types/NewProduct"
import { UpdateProductType } from "../../types/UpdateProduct"

const initilState: {
  products: ProductType[]
  loading: boolean
  error: string
} = {
  products: [],
  loading: false,
  error: "",
}

export const fetchProductData = createAsyncThunk(
  "getProduct",
  async (params) => {
    try {
      const request = await axios.get<ProductType[]>(
        `${process.env.REACT_APP_URL}/api/v1/products`
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const createProduct = createAsyncThunk(
  "createProduct",
  async (product: NewProductType) => {
    try {
      const request = await axios.post<ProductType>(
        `${process.env.REACT_APP_URL}/api/v1/products`,
        product,
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
      if (error.response) {
        return JSON.stringify(error.response.data)
      }
      return error.message
    }
  }
)

export const updateProduct = createAsyncThunk(
  "updateProduct",
  async (product: UpdateProductType) => {
    try {
      const request = await axios.put<ProductType>(
        `${process.env.REACT_APP_URL}/api/v1/products/${product.id}`,
        product.update,
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

export const deleteProduct = createAsyncThunk(
  "deleteProduct",
  async (id: string) => {
    try {
      const request = await axios.delete<boolean>(
        `${process.env.REACT_APP_URL}/api/v1/products/${id}`,
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
  }
)

export const getProductByCategoryId = createAsyncThunk(
  "getProductByCategoryId",
  async (id: string) => {
    try {
      const request = await axios.get<ProductType[]>(
        `${process.env.REACT_APP_URL}/api/v1/products/category/${id}`
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const getByProductId = createAsyncThunk(
  "getByProductId",
  async (id: string) => {
    try {
      const request = await axios.get<ProductType>(
        `${process.env.REACT_APP_URL}/api/v1/products/${id}`
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

const productSlice = createSlice({
  name: "product",
  initialState: initilState,
  reducers: {
    clearProductStore: (state) => {
      return initilState
    },
    clearProductError: (state) => {
      state.error = ""
    },
  },
  extraReducers: (build) => {
    build
      .addCase(fetchProductData.pending, (state) => {
        state.loading = true
      })
      .addCase(fetchProductData.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = action.payload.message
        } else {
          state.products = action.payload
        }
        state.loading = false
      })
      .addCase(fetchProductData.rejected, (state, action) => {
        state.error = "Server Error during fetching product data."
      })
      .addCase(createProduct.fulfilled, (state, action) => {
        if (typeof action.payload === "string") {
          state.error = action.payload
        } else {
          state.products.push(action.payload)
        }
        state.loading = false
      })
      .addCase(createProduct.pending, (state, actioin) => {
        state.loading = true
      })
      .addCase(createProduct.rejected, (state, actioin) => {
        state.error = "Server Error during creating product."
      })
      .addCase(updateProduct.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = action.payload.message
        } else {
          const newitem = action.payload
          const products = state.products.map((product) => {
            if (newitem.id === product.id) {
              return { ...product, ...newitem }
            }
            return product
          })

          return {
            ...state,
            products,
          }
        }
      })
      .addCase(updateProduct.pending, (state, actioin) => {
        state.loading = true
      })
      .addCase(updateProduct.rejected, (state, actioin) => {
        state.error = "Server Error occured during updating product."
      })
      .addCase(deleteProduct.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = action.payload.message
        } else {
          if (action.payload.response === true) {
            const response = action.payload
            const updatedArray = state.products.filter(
              (item) => item.id !== response.id
            )
            state.products = updatedArray
          } else {
            state.error = "Delete request failed."
          }
        }
        state.loading = false
      })
      .addCase(deleteProduct.rejected, (state, actioin) => {
        state.error = "Server Error occured during deleting product."
      })
  },
})

const productReducer = productSlice.reducer
export const { clearProductStore, clearProductError } = productSlice.actions

export default productReducer
