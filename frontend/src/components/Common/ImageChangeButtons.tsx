/**
 * @file ImageChangeButtons
 * @description Buttons for changing image of the product card, cart card and update product cart
 * @Author Vikas Singh
 */
import React from "react"
import { IconButton, Typography } from "@mui/material"
import { ArrowBackIos, ArrowForwardIos } from "@mui/icons-material"

/**
 *
 * @param imagesNo: number = number of images
 * @param currentImage: number = current image number
 * @param setCurrentImage: React.Dispatch<React.SetStateAction<number>>
 * if imagesNo === 0
 * @returns null
 * else
 * @returns JSX.Element for changing image
 */
export const ImageChangeButtons = ({
  imagesNo,
  currentImage,
  setCurrentImage,
}: {
  imagesNo: number
  currentImage: number
  setCurrentImage: React.Dispatch<React.SetStateAction<number>>
}) => {
  const moveImageLeft = () =>
    currentImage > 0 ? setCurrentImage(currentImage - 1) : null
  const moveImageRight = () =>
    currentImage + 1 < imagesNo ? setCurrentImage(currentImage + 1) : null

  return (
    <>
      {imagesNo > 1 && (
        <Typography
          sx={{
            display: "flex",
            flexDirection: "row",
            justifyContent: "normal",
            width: "inherit",
          }}
        >
          <IconButton
            onClick={moveImageLeft}
            className="productCategory--container--imageBtn"
            style={
              // disable button if no image on left
              currentImage === 0
                ? { cursor: "not-allowed", opacity: "0.4" }
                : {}
            }
          >
            <ArrowBackIos titleAccess="Previous Image" />
          </IconButton>
          <IconButton
            onClick={moveImageRight}
            className="productCategory--container--imageBtn"
            style={
              // disable button if no image on right
              currentImage + 1 === imagesNo
                ? { cursor: "not-allowed", opacity: "0.4" }
                : {}
            }
          >
            <ArrowForwardIos titleAccess="Next Image" />
          </IconButton>
        </Typography>
      )}
    </>
  )
}
