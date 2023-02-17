<template>
  <div class="authorization-menu-home">
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
  name: "LogoutNavbarMenuHome",
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