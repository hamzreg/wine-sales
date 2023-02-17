<template>
  <HomeBackground>
    <img src="@/assets/img/logo.png" height="500" class="logo"/>
  </HomeBackground>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import HomeBackground from "@/components/background/HomeBackground.vue"

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
  display: flex;
  flex-direction: column;
  position: absolute;
  left: 35%;
  bottom: 0%;
}
</style>