import { Card, styled, Box, CardMedia } from "@mui/material"

const DisplayCardHorizontal = styled(Card)(({ theme }) => ({
  display: "flex",
  justifyContent: "normal",
  alignContent: "center",
  height: "100%",
  width: "100%",
}))

const HorizontalCardBox = styled(Box)(({ theme }) => ({
  display: "flex",
  flexDirection: "column",
  height: "100%",
  width: "50%",
}))

const HorizontalCardMedia = styled(CardMedia)(({ theme }) => ({}))

export { DisplayCardHorizontal, HorizontalCardMedia, HorizontalCardBox }
