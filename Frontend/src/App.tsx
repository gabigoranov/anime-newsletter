import Features from "./components/landing/Features";
import Footer from "./components/landing/Footer";
import Hero from "./components/landing/Hero";
import Navbar from "./components/landing/Navbar";

export default function App() {
  return (
    <div className="bg-background text-on-background min-h-screen flex flex-col selection:bg-primary-container selection:text-on-primary-container font-body-md">
      <Navbar />
      <main className="grow">
        <Hero />
        <Features />
      </main>
      <Footer />
    </div>
  );
}