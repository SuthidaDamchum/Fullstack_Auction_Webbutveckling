import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import AuctionListPage from "./pages/AuctionListPage/AuctionListPage";
import LoginPage from "./pages/LoginPage/LoginPage";
import Navbar from "./components/Navbar/Navbar";

const App = () => {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route path="/" element={<Navigate to="/auctions" />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/auctions" element={<AuctionListPage />} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
};

export default App;
