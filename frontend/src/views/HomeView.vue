<template>
  <HomeBackground>
    <NavBarHomeView>
      <img src="@/assets/img/logo.png" height="500" class="logo"/>
    </NavBarHomeView>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"
import NavBarHomeView from '@/views/NavBarHomeView.vue'

export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    HomeBackground,
    NavBarHomeView,
  },
});
</script>


<style scoped>
.logo {
  display: flex;
  flex-direction: column;
  position: absolute;
  left: 35%;
  bottom: 0%;
}
</style>