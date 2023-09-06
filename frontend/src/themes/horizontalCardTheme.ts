import { Card, styled, Box, CardMedia } from "@mui/material"

const DisplayCardHorizontal = styled(Card)(({ theme }) => ({
  display: "flex",
  justifyContent: "normal",
  alignContent: "center",
}))

const HorizontalCardBox = styled(Box)(({ theme }) => ({
  display: "flex",
  flexDirection: "column",
  height: "max-content",
}))

const HorizontalCardMedia = styled(CardMedia)(({ theme }) => ({}))

export { DisplayCardHorizontal, HorizontalCardMedia, HorizontalCardBox }
