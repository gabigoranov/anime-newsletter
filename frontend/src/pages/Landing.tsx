import Features from "../components/landing/Features";
import Footer from "../components/landing/Footer";
import Hero from "../components/landing/Hero";
import Navbar from "../components/landing/Navbar";
import SignUpModal from "../components/SignUpModal";
import { useModal } from "../hooks/useModal";

export default function Landing() {
  const { isSignupOpen, closeSignup, signupEmail } = useModal();

  return (
    <div className="bg-background text-on-background min-h-screen flex flex-col selection:bg-primary-container selection:text-on-primary-container font-body-md">
      <Navbar />
      <main className="grow">
        <Hero />
        <Features />
      </main>
      <Footer />

      <SignUpModal
        isOpen={isSignupOpen}
        onClose={closeSignup}
        initialEmail={signupEmail}
      />
    </div>
  );
}
