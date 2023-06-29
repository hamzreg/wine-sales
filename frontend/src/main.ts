import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import Notifications from '@kyvg/vue3-notification'

createApp(App).use(Notifications).use(store).use(router).mount('#app')
