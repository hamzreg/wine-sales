<template>
    <Background>
        <FormButton>
            Авторизация
        </FormButton>
    </Background>
</template>
  
  
<script lang="ts">
import { defineComponent } from "vue";
import Background from "@/components/background/Background.vue"
import FormButton from "@/components/button/FormButton.vue"

export default defineComponent({
setup() {
    // auth.logout()
},
components: {
    Background,
    FormButton
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