<template>
  <HomeBackground>
    <NavBarView>
      <img src="@/assets/img/logo.png" height="500" class="logo"/>
    </NavBarView>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"
import NavBarView from '@/views/NavBarView.vue'

export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    HomeBackground,
    NavBarView,
  },
});
</script>


<style scoped>
.logo {
  position: absolute;
  left: 35%;
  bottom: 0%;
}
</style>