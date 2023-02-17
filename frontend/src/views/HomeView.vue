<template>
  <HomeBackground>
    <img src="@/assets/img/logo.png" height="500" class="logo"/>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/HomeBackground.vue"

export default defineComponent({
  setup() {
    // auth.logout()
  },
  components: {
    HomeBackground
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