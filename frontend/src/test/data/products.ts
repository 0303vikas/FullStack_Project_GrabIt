import { NewProductType } from "../../types/NewProduct"
import { ProductType } from "../../types/Product"
import { UpdateProductType } from "../../types/UpdateProduct"
import { category1, category2, category3 } from "./categories"

const product1: ProductType = {
  id: "1",
  title: "A  product",
  price: 100,
  description: "product 1",
  imageURLList: [],
  category: category1,
}

const product2: ProductType = {
  id: "2",
  title: "B  product",
  price: 300,
  description: "product 2",
  imageURLList: [],
  category: category2,
}

const product3: ProductType = {
  id: "3",
  title: "C  product",
  price: 200,
  description: "product 3",
  imageURLList: [],
  category: category3,
}

const product4: ProductType = {
  id: "4",
  title: "D  product",
  price: 50,
  description: "product 4",
  imageURLList: [],
  category: category1,
}

const newProduct: NewProductType = {
  title: "E product",
  price: 500,
  stock: 10,
  description: "new product",
  imageURLList: ["https://placeimg.com/640/480/any"],
  categoryId: "3",
}

const invalidProduct: NewProductType = {
  title: "E product",
  price: 0,
  stock: 10,
  description: "new product",
  imageURLList: [],
  categoryId: "5",
}

const updatedProduct4: UpdateProductType = {
  id: "4",
  update: {
    title: "Updated D product",
    price: 10,
    stock: 10,
    description: "updated product",
    imageURLList: ["https://placeimg.com/640/480/any"],
    categoryId: "3",
  },
}

export {
  product1,
  product2,
  product3,
  product4,
  updatedProduct4,
  newProduct,
  invalidProduct,
}
const Products = [product1, product2, product3, product4]

export default Products
