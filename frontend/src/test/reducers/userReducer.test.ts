import {
  createUserLocally,
  fetchAllUsers,
  clearAllUsers,
} from "../../redux/reducers/userReducer"
import store from "../shared/store"
import users, { user1, user2, user3 } from "../data/user"
import { userServer } from "../servers/userServer"
import userReducer from "../../redux/reducers/userReducer"
import { UserType } from "../../types/User"

beforeAll(() => {
  userServer.listen()
})

afterAll(() => {
  userServer.close()
})

beforeEach(() => {
  store.dispatch(clearAllUsers())
  store.dispatch(createUserLocally(user1))
  store.dispatch(createUserLocally(user2))
  store.dispatch(createUserLocally(user3))
})

describe("Testing User Reducer", () => {
  test("Test initial State of store", () => {
    const state = userReducer(undefined, { type: "unknown" })
    expect(state).toEqual({
      users: [],
      loading: false,
      error: {
        message: "",
        statusCode: 200,
      },
      authloading: true,
    })
  })
  test("Fetch all Users", async () => {
    await store.dispatch(fetchAllUsers())
    expect(store.getState().user.users.length).toBe(3)
  })
  test("Create User", async () => {
    const user: UserType = {
      id: "1",
      email: "test@gmail.com",
      role: 1,
      password: "tester",
      firstName: "Tester",
      lastName: "TestLast",
      imageURL: "",
    }
    const state = userReducer(undefined, createUserLocally(user))
    expect(state).toEqual({
      users: [user],
      loading: false,
      authloading: true,
      error: {
        message: "",
        statusCode: 200,
      },
    })
  })
})
