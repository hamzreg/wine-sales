<template>
  <HomeBackground>
  <div class="home">
    <img src="../assets/img/logo.png" height="100"/>
  </div>
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
