import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TestView from '../views/TestView.vue'
import TestViewGadzhi from '../views/TestViewGadzhi.vue'
import Authorization from '../views/AuthorizationView.vue'
import Registration from '../views/RegistrationView.vue'
import AdminSalesView from '@/views/AdminSalesView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },

  {
    path: '/test',
    name: 'test',
    component: TestView
  },

  {
    path: '/testG',
    name: 'testG',
    component: TestViewGadzhi
  },

  {
    path: '/auth',
    name: 'Authorization',
    component: Authorization
  },

  {
    path: '/registration',
    name: 'Registration',
    component: Registration
  },

  {
    path: '/sales',
    name: 'Sales',
    component: AdminSalesView
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
