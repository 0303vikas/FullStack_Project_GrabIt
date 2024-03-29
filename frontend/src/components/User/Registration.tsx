/**
 * @file Registration
 * @description User Registration Component
 * @Author Vikas Singh
 */
import { useForm, SubmitHandler, Controller } from "react-hook-form"
import { Input, useTheme } from "@mui/material"
import { useNavigate } from "react-router-dom"

import ContainerLoginRegister, {
  FormContainerLoginRegister,
  HeadingContainer,
  ImageContainer,
  SubmitBtn,
} from "../../themes/formTheme"
import { RegistrationType } from "../../types/NewUser"
import { useAppDispatch } from "../../hooks/useAppDispatch"
import { useAppSelector } from "../../hooks/useAppSelector"
// import { checkEmailAvailableHook } from "../hooks/checkEmailAvailibility"
import darkLogo from "../../icons/DarkImage.png"
import lightLogo from "../../icons/LightImage.png"
import {
  clearUserError,
  clearUserLogin,
  createUser,
  fetchAllUsers,
} from "../../redux/reducers/userReducer"
import { useEffect } from "react"
import { ErrorComponent } from "../Common/ErrorComponent"
import { AxiosError } from "axios"

/**
 * @description For registing new users, for data consists of username, useremail, password and image upload
 * @returns JSX.Element registration form
 */
const Registration = () => {
  const dispatch = useAppDispatch()
  const theme = useTheme()
  const navigate = useNavigate()
  const userStore = useAppSelector((store) => store.user)
  const {
    handleSubmit,
    setError,
    control,
    formState: { errors },
    watch,
    register,
  } = useForm<RegistrationType>()

  const onSubmit: SubmitHandler<RegistrationType> = (data, e) => {
    e?.preventDefault()
    // const isEmailExisting = checkEmailAvailableHook(userStore.users, data.email)
    // if (isEmailExisting) {
    //   setError("email", {
    //     type: "manual",
    //     message: "Email is not available",
    //   })
    //   return false
    // }

    const userData = {
      firstName: data.firstName,
      lastName: data.lastName,
      email: data.email,
      password: data.password,
      imageURL: data.imageURL,
    }

    dispatch(createUser(userData)).then((data) => {
      if (data.type === "createUser/fulfilled") {
        if (data.payload instanceof AxiosError) {
          setTimeout(() => {
            dispatch(clearUserError())
          }, 3000)
          return false
        } else {
          alert("User Created Successfully")
          navigate("/")
        }
      } else {
        setTimeout(() => {
          dispatch(clearUserLogin())
        }, 3000)
      }
    })
  }
  const password = watch("password")
  const retryPassword = watch("retryPassword")

  const validatePasswordReset = (value: string) => {
    if (value === password) {
      return true
    } else {
      return "Password do not match"
    }
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
          rowGap: "1rem",
        }}
        encType="multipart/form-data"
        onSubmit={handleSubmit(onSubmit)}
      >
        <HeadingContainer>SIGN UP</HeadingContainer>
        <Controller
          name="firstName"
          defaultValue=""
          control={control}
          rules={{
            required: "FirstName is required",
          }}
          render={({ field }) => (
            <>
              <Input
                className="input--firstName"
                type="string"
                placeholder="First Name"
                sx={{
                  fontWeight: "bolder",
                  color: theme.palette.common.black,
                  backgroundColor: theme.palette.common.white,
                }}
                color={errors.firstName ? "error" : "secondary"}
                required
                {...field}
              />
              {errors.firstName && (
                <p
                  style={{
                    color: theme.palette.error.main,
                    fontSize: theme.typography.fontSize,
                    margin: "0",
                  }}
                >
                  *{errors.firstName.message}
                </p>
              )}
            </>
          )}
        />
        <Controller
          name="lastName"
          defaultValue=""
          control={control}
          rules={{
            required: "LastName is required",
          }}
          render={({ field }) => (
            <>
              <Input
                className="input--lastName"
                type="string"
                placeholder="Last Name"
                sx={{
                  fontWeight: "bolder",
                  color: theme.palette.common.black,
                  backgroundColor: theme.palette.common.white,
                }}
                color={errors.lastName ? "error" : "secondary"}
                required
                {...field}
              />
              {errors.lastName && (
                <p
                  style={{
                    color: theme.palette.error.main,
                    fontSize: theme.typography.fontSize,
                    margin: "0",
                  }}
                >
                  *{errors.lastName.message}
                </p>
              )}
            </>
          )}
        />
        <Controller
          name="email"
          defaultValue=""
          control={control}
          rules={{
            required: "Email is Required",
            pattern: {
              value: /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i,
              message: "Invalid email address",
            },
          }}
          render={({ field }) => (
            <>
              <Input
                className="input--email"
                type="string"
                placeholder="Email"
                sx={{
                  fontWeight: "bolder",
                  color: theme.palette.common.black,
                  backgroundColor: theme.palette.common.white,
                }}
                color={errors.email ? "error" : "secondary"}
                required
                {...field}
              />
              {errors.email && (
                <p
                  style={{
                    color: theme.palette.error.main,
                    fontSize: theme.typography.fontSize,
                    margin: "0",
                  }}
                >
                  *{errors.email.message}
                </p>
              )}
            </>
          )}
        />
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
                  color: theme.palette.common.black,
                  backgroundColor: theme.palette.common.white,
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
          defaultValue=""
          control={control}
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
                  color: theme.palette.common.black,
                  backgroundColor: theme.palette.common.white,
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

        <Controller
          name="imageURL"
          defaultValue=""
          control={control}
          rules={{
            required: "ProfileImageURL is Required",
          }}
          render={({ field }) => (
            <>
              <Input
                className="input--image"
                type="string"
                placeholder="ProfileImageURL"
                sx={{
                  fontWeight: "bolder",
                  color: theme.palette.common.black,
                  backgroundColor: theme.palette.common.white,
                }}
                color={errors.imageURL ? "error" : "secondary"}
                required
                {...field}
              />
              {errors.imageURL && (
                <p
                  style={{
                    color: theme.palette.error.main,
                    fontSize: theme.typography.fontSize,
                    margin: "0",
                  }}
                >
                  *{errors.imageURL.message}
                </p>
              )}
            </>
          )}
        />
        {userStore.error.message && (
          <ErrorComponent
            message={userStore.error.message}
            statusCode={userStore.error.statusCode}
          />
        )}
        <SubmitBtn type="submit">Register</SubmitBtn>
      </FormContainerLoginRegister>
    </ContainerLoginRegister>
  )
}

export default Registration
