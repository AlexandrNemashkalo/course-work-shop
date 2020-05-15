import Vue from 'vue'
import VueRouter from 'vue-router'
import Main from '../views/Main.vue'
import Item from '../views/Item.vue'
import Items from '../views/Items.vue'
import Login from '../views/Login.vue'
import ForgotPassword from '../views/ForgotPassword.vue'
import Register from '../views/Register.vue'
import MyItems from '../views/MyItems.vue'
import Admin from '../views/Admin.vue'
import AUsers from '../views/adminVue/AUsers.vue'
import AUser from '../views/adminVue/AUser.vue'
import AItems from '../views/adminVue/AItems.vue'
import ACategories from '../views/adminVue/ACategories.vue'
import AOrders from '../views/adminVue/AOrders.vue'
import AComments from '../views/adminVue/AComments.vue'
import ARatings from '../views/adminVue/ARatings.vue'
import ANews from '../views/adminVue/ANews.vue'
import AEvents from '../views/adminVue/AEvents.vue'
import test from '../views/test.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Main',
    component: Main
  },
  {
    path:'/item/:id',
    name: 'Item',
    component: Item
  },
  {
    path:'/login',
    name: 'Login',
    component: Login
  },
  {
    path:'/register',
    name: 'Register',
    component: Register
  },
  {
    path:'/forgotpassword',
    name: 'ForgotPassword',
    component: ForgotPassword
  },
  {
    path:'/order',
    name: 'MyItems',
    component: MyItems
  },
  {
    path:'/items/:idCategory',
    name: 'Items',
    component: Items
  },
  {
    path:'/admin',
    name: 'Admin',
    component: Admin
  },

 {
    path:'/admin/users',
    name: 'AUsers',
    component: AUsers
  },
  {
    path:'/admin/users/:idUser',
    name: 'AUser',
    component: AUser
  },
  {
    path:'/admin/items',
    name: 'AItems',
    component: AItems
  },
  {
    path:'/admin/categories',
    name: 'ACategories',
    component: ACategories
  },
  {
    path:'/admin/orders',
    name: 'AOrders',
    component: AOrders
  },
  {
    path:'/admin/comments',
    name: 'AComments',
    component: AComments
  },
  {
    path:'/admin/ratings',
    name: 'ARatings',
    component: ARatings
  },
  {
    path:'/admin/news',
    name: 'ANews',
    component: ANews
  },
  {
    path:'/admin/events',
    name: 'AEvents',
    component: AEvents
  },
  {
    path:'/test',
    name: 'ATest',
    component: test
  },


 
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
