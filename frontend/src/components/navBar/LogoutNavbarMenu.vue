<template>
  <div class="authorization-menu">
    <HomeButton @click="logout">
      Выйти
    </HomeButton>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import HomeButton from '@/components/button/HomeButton.vue'
// import auth from "@/authentificationService"

export default defineComponent({
  name: "LogoutNavbarMenu",
  components: {
    HomeButton,
  },
  methods: {
    logout () {
      // auth.logout();
      // this.$router.push({ path: '/authorization' })
    },
  }
})
</script>