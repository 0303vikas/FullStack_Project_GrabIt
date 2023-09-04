import { Button, Input, Theme } from "@mui/material"
import { Controller, SubmitHandler, useForm } from "react-hook-form"
import { AxiosError } from "axios"

import { UserType } from "../../types/User"
import {
  clearUserError,
  updatePassword,
} from "../../redux/reducers/userReducer"
import { useAppDispatch } from "../../hooks/useAppDispatch"

interface PasswordType {
  password: string
  retryPassword: string
}

export const PasswordUpdateForm = ({
  currentUser,
  theme,
}: {
  currentUser: UserType
  theme: Theme
}) => {
  const {
    handleSubmit,
    control,
    formState: { errors },
    watch,
    reset,
  } = useForm<PasswordType>()

  const dispatch = useAppDispatch()

  const validatePasswordReset = (value: string) => {
    if (value === password) {
      return true
    } else {
      return "Password do not match"
    }
  }

  const password = watch("password")

  const updatePasswordHandler: SubmitHandler<PasswordType> = (data, e) => {
    e?.preventDefault()

    if (currentUser) {
      const updateData = {
        id: currentUser.id,
        password: data.password,
      }
      dispatch(updatePassword(updateData)).then((data) => {
        if (data.type === "updatePassword/fulfilled") {
          if (data.payload instanceof AxiosError) {
            setTimeout(() => {
              dispatch(clearUserError())
            }, 3000)
            return false
          } else {
            alert("User password updated successfully.")
          }
        }
      })
    }
    reset()
  }

  return (
    <form
      onSubmit={handleSubmit(updatePasswordHandler)}
      style={{ border: "black 1px solid", padding: "1rem", margin: "1rem 0" }}
    >
      <h4 style={{ color: theme.palette.warning.main }}>Reset Your Password</h4>
      <Controller
        name="password"
        defaultValue=""
        control={control}
        rules={{
          required: "Password is required",
          minLength: {
            value: 6,
            message: "Password must be at least 6 characters long",
          },
        }}
        render={({ field }) => (
          <>
            <Input
              className="input--password"
              type="password"
              placeholder="Password"
              sx={{
                fontWeight: "bolder",
                color: "black",
              }}
              color={errors.password ? "error" : "secondary"}
              required
              {...field}
            />
            {errors.password && (
              <p
                style={{
                  color: theme.palette.error.main,
                  fontSize: theme.typography.fontSize,
                  margin: "0",
                }}
              >
                *{errors.password.message}
              </p>
            )}
          </>
        )}
      />
      <Controller
        name="retryPassword"
        control={control}
        defaultValue=""
        rules={{
          required: "Password confirmation is required",
          validate: validatePasswordReset,
        }}
        render={({ field }) => (
          <div>
            <Input
              className="input--password"
              type="password"
              placeholder="ReEnter Password"
              sx={{
                fontWeight: "bolder",
                color: "black",
              }}
              color={errors.retryPassword ? "error" : "secondary"}
              required
              {...field}
            />
            {errors.retryPassword && (
              <p
                style={{
                  color: theme.palette.error.main,
                  fontSize: theme.typography.fontSize,
                  margin: "0",
                }}
              >
                *{errors.retryPassword.message}
              </p>
            )}
          </div>
        )}
      />
      <Button variant="contained" color="warning" type="submit">
        Reset
      </Button>
    </form>
  )
}
