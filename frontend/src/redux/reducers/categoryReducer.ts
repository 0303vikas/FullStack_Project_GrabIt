import axios, { AxiosError } from "axios"
import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit"

import { CategoryType, UpdateCategoryType } from "../../types/Category"

const initialState: {
  category: CategoryType[]
  loading: boolean
  error: string
} = {
  category: [],
  loading: false,
  error: "",
}

export const fetchCategoryData = createAsyncThunk("getCategory", async () => {
  try {
    const request = await axios.get<CategoryType[]>(
      `${process.env.REACT_APP_URL}/api/v1/categorys`
    )
    return request.data
  } catch (e) {
    const error = e as AxiosError
    return error
  }
})

export const getCategoryById = createAsyncThunk(
  "getCategoryById",
  async (id: string) => {
    try {
      const request = await axios.get<CategoryType>(
        `${process.env.REACT_APP_URL}/api/v1/categorys/${id}`
      )
      return request.data
    } catch (e) {
      const error = e as AxiosError
      return error
    }
  }
)

export const createCategory = createAsyncThunk(
  "createCategory",
  async (category: Omit<CategoryType, "id">) => {
    try {
      const request = await axios.post(
        `${process.env.REACT_APP_URL}/api/v1/categorys`,
        category,
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

export const updateCategory = createAsyncThunk(
  "updateCategory",
  async (category: UpdateCategoryType) => {
    try {
      const request = await axios.put<CategoryType>(
        `${process.env.REACT_APP_URL}/api/v1/categorys/${category.id}`,
        category.update,
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

export const deleteCategory = createAsyncThunk(
  "deleteCategory",
  async (id: string) => {
    try {
      const request = await axios.delete<boolean>(
        `${process.env.REACT_APP_URL}/api/v1/categorys/${id}`,
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
      if (error.response) {
        return JSON.stringify(error.response.data)
      }
      return error
    }
  }
)

const categorySlice = createSlice({
  name: "category",
  initialState: initialState,
  reducers: {
    clearAllCategory: (state) => {
      return initialState
    },
    clearCategoryError: (state) => {
      state.error = ""
    },
    sortCategory: (state, action: PayloadAction<"asc" | "desc">) => {
      if (action.payload === "asc") {
        state.category.sort((a, b) =>
          a.name > b.name ? 1 : a.name < b.name ? -1 : 0
        )
      } else {
        state.category.sort((a, b) =>
          a.name < b.name ? 1 : a.name > b.name ? -1 : 0
        )
      }
    },
  },

  extraReducers: (build) => {
    build
      .addCase(fetchCategoryData.pending, (state) => {
        state.loading = true
      })
      .addCase(fetchCategoryData.fulfilled, (state, action) => {
        if (action.payload instanceof AxiosError) {
          state.error = action.payload.message
        } else {
          state.category = action.payload
        }
        state.loading = false
      })
      .addCase(fetchCategoryData.rejected, (state) => {
        state.error = "Cannot Fetch Data"
      })
      .addCase(createCategory.fulfilled, (state, action) => {
        if (typeof action.payload === "string") {
          state.error = action.payload
        } else {
          state.category.push(action.payload)
        }
        state.loading = false
      })
      .addCase(createCategory.rejected, (state, action) => {
        state.error = "Cannot Create Category."
      })
      .addCase(updateCategory.fulfilled, (state, action) => {
        if (typeof action.payload === "string") {
          state.error = action.payload
        } else {
          const updatedItem = action.payload
          const category = state.category.map((item) => {
            if (item.id === updatedItem.id) {
              return { ...item, ...updatedItem }
            }
            return item
          })
          return {
            ...state,
            category,
          }
        }
      })
      .addCase(updateCategory.rejected, (state, action) => {
        state.error = "Cannot Update Category."
      })
      .addCase(deleteCategory.fulfilled, (state, action) => {
        if (typeof action.payload === "string") {
          state.error = action.payload
        } else {
          if (action.payload.response === true) {
            const deleteId = action.payload.id
            const newCategoryList = state.category.filter(
              (item) => item.id !== deleteId
            )
            state.category = newCategoryList
          } else {
            state.error = "An Error occured during Deleting Category."
          }
        }
      })
      .addCase(deleteCategory.rejected, (state, action) => {
        state.error = "Cannot Delete Category."
      })
  },
})

const categoryReducer = categorySlice.reducer
export const { sortCategory, clearAllCategory, clearCategoryError } =
  categorySlice.actions

export default categoryReducer
