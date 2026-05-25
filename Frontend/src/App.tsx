import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import AuctionListPage from "./pages/AuctionListPage/AuctionListPage";
import LoginPage from "./pages/LoginPage/LoginPage";

const App = () => {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/auctions" element={<AuctionListPage />} />
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  );
};

export default App;
