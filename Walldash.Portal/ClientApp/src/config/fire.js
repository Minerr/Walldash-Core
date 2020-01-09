import firebase from "firebase";

var firebaseConfig = {
    apiKey: "AIzaSyAQmlB1wynYmMzJT-Uq5d4NdgbjwT8gZsI",
    authDomain: "walldash-database.firebaseapp.com",
    databaseURL: "https://walldash-database.firebaseio.com",
    projectId: "walldash-database",
    storageBucket: "walldash-database.appspot.com",
    messagingSenderId: "570685470487",
    appId: "1:570685470487:web:65e8f1a0d5735146f82952",
    measurementId: "G-GDH6G7WHLN"
};

const fire = firebase.initializeApp(firebaseConfig);
export default fire;