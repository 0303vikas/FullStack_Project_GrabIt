/**
 * @file Home Page
 * @description Home Page with Navigation and Outlet
 * @Author Vikas Singh
 */
import { Outlet } from "react-router-dom"

import { FooterContainer, HeaderContainer } from "../themes/HomePageTheme"
import {
  NavigationLeft,
  NavigationMiddle,
  NavigationRight,
} from "../components/Common/NavigationBar"
import { useAppSelector } from "../hooks/useAppSelector"
import ErrorComponent from "./Error"
import { Footer } from "../components/Common/Footer"

/**
 * if error
 * @returns JSX.Element Error
 * else
 * @returns JSX.Element OutLet
 */
const Home = () => {
  const reduxErrorState = useAppSelector((state) => state)
  const productsError = reduxErrorState.product.error
  const categoryError = reduxErrorState.categories.error

  return (
    <>
      <HeaderContainer>
        <NavigationLeft />
        <NavigationMiddle />
        <NavigationRight />
      </HeaderContainer>
      {productsError.length > 0 || categoryError.length > 0 ? (
        <ErrorComponent />
      ) : (
        <Outlet />
      )}
      <FooterContainer>
        <Footer />
      </FooterContainer>
    </>
  )
}

export default Home
