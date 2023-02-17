import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import TestView from '../views/TestView.vue'
import TestViewGadzhi from '../views/TestViewGadzhi.vue'
import Authorization from '../views/AuthorizationView.vue'

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
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
