/**
 * @file Login
 * @description User Login Component
 * @Author Vikas Singh
 * @note
 * - component is passed to withLoading page
 * - after loading is finished, this display will handle data rendering on home page
 */

import { useForm, SubmitHandler, Controller } from "react-hook-form"
import { Input, useTheme } from "@mui/material"
import { useNavigate } from "react-router-dom"
import { useState } from "react"

import ContainerLoginRegister, {
  FormContainerLoginRegister,
  HeadingContainer,
  ImageContainer,
  SubmitBtn,
} from "../themes/formTheme"
import darkLogo from "../icons/DarkImage.png"
import lightLogo from "../icons/LightImage.png"
import { useAppDispatch } from "../hooks/useAppDispatch"
import { useAppSelector } from "../hooks/useAppSelector"
import {
  clearUserError,
  clearUserLogin,
  loginUser,
} from "../redux/reducers/userReducer"
import { ErrorComponent } from "./ErrorComponent"
import { AxiosError } from "axios"

interface LoginForm {
  userEmail: string
  password: string
}

/**
 * @description Login component
 * @returns JSX.Element
 * @notes
 *  - validation errors are displayed in the form
 *  - login rejection error are handled by error page
 */
const Login = () => {
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<LoginForm>()
  const dispatch = useAppDispatch()
  const userStore = useAppSelector((state) => state.user)
  const theme = useTheme()
  const navigate = useNavigate()

  const onSubmit: SubmitHandler<LoginForm> = (data, e) => {
    e?.preventDefault()

    const loginData = {
      email: data.userEmail,
      password: data.password,
    }

    dispatch(loginUser(loginData)).then((data) => {
      if (data.type === "login/fulfilled") {
        if (data.payload instanceof AxiosError) {
          setTimeout(() => {
            dispatch(clearUserError())
          }, 3000)
          return false
        } else {
          alert("User Logged In Successfully")
          navigate("/")
        }
      } else {
        setTimeout(() => {
          dispatch(clearUserLogin())
        }, 3000)
      }
    })
  }

  return (
    <ContainerLoginRegister>
      <ImageContainer
        src={theme.palette.mode === "light" ? lightLogo : darkLogo}
      />
      <FormContainerLoginRegister
        style={{
          display: "flex",
          justifyContent: "center",
        }}
        onSubmit={handleSubmit(onSubmit)}
      >
        <HeadingContainer>SIGN IN</HeadingContainer>

        <Controller
          name="userEmail"
          defaultValue=""
          control={control}
          rules={{
            required: "*Email is required.",
          }}
          render={({ field }) => (
            <div>
              <Input
                className="input--userEmail"
                type="string"
                placeholder="Email"
                style={{
                  fontWeight: "bolder",
                  color: theme.palette.common.black,
                }}
                color={errors.userEmail ? "error" : "secondary"}
                required
                {...field}
                autoComplete="email"
              />
              {errors.userEmail && (
                <p
                  style={{
                    color: theme.palette.error.main,
                    fontSize: theme.typography.fontSize,
                    margin: "0",
                  }}
                >
                  *{errors.userEmail.message}
                </p>
              )}
            </div>
          )}
        />

        <Controller
          name="password"
          control={control}
          defaultValue=""
          rules={{
            required: "*Password is required",
          }}
          render={({ field }) => (
            <div>
              <Input
                className="input--password"
                type="password"
                placeholder="Password"
                sx={{
                  fontWeight: "bolder",
                  color: theme.palette.common.black,
                }}
                color={errors.password ? "error" : "secondary"}
                required
                {...field}
                autoComplete="current-password"
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
            </div>
          )}
        />
        {userStore.error.message && (
          <ErrorComponent
            message={userStore.error.message}
            statusCode={userStore.error.statusCode}
          />
        )}
        <SubmitBtn type="submit">Log In</SubmitBtn>
      </FormContainerLoginRegister>
    </ContainerLoginRegister>
  )
}

export default Login
