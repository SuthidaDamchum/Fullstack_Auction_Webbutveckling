import { useState, useEffect } from "react";
import type { Auction } from "../../types/Auction";
import { getAllAuctions } from "../../services/auctionService";
import styles from "./AuctionListPage.module.css";

const AuctionListPage = () => {
  const [auctions, setAuctions] = useState<Auction[]>([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    getAllAuctions()
      .then((data) => {
        console.log("API svar:", data);
        setAuctions(data);
      })
      .catch((err) => console.error("Fel:", err));
  }, []);

  const filteredAuctions = auctions.filter((a) =>
    a.title.toLowerCase().includes(search.toLowerCase()),
  );

  return (
    <div className={styles.container}>
      <h1>Auktioner</h1>

      <input
        type="text"
        placeholder="Sök auktion..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        className={styles.search}
      />

      <div className={styles.grid}>
        {filteredAuctions.map((auction) => (
          <div key={auction.id} className={styles.card}>
            {auction.imageUrl && (
              <img src={auction.imageUrl} alt={auction.title} />
            )}
            <h2>{auction.title}</h2>
            <p>{auction.description}</p>
            <p>Pris: {auction.price} kr</p>
            <a href={`/auctions/${auction.id}`}>Visa</a>
          </div>
        ))}
      </div>
    </div>
  );
};

export default AuctionListPage;
