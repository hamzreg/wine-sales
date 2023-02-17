<template>
  <router-view/>
</template>


<style>
@font-face {
  font-family: "Frenchpress";
  src: local("Frenchpress"),
   url(./assets/fonts/Frenchpress.otf) format("truetype");
}

#app {
  font-family: "Frenchpress";
}

:root {
  --tiny-text: 24px;
  --little-text: 32px;
  --middle-text: 48px;
  --large-text: 60px;
  --huge-text: 96px;

  --green-color: #465F5A;
  --emerald-color: #225721;
  --beige-color: #F8EFE5;
  --wine-color: #A12626;

  --font-name: "Frenchpress";
}
</style>
