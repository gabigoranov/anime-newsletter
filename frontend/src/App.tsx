import Landing from "./pages/Landing";
import { ModalProvider } from "./providers/ModalProvider";

export default function App() {
  return (
    <ModalProvider>
      <Landing />
    </ModalProvider>
  );
}
