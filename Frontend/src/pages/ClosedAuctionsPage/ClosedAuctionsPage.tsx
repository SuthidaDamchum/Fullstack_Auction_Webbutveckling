import styles from "./ClosedAuctionsPage.module.css";
import type { Auction } from "../../types/Auction";
import { getClosedAuctions } from "../../services/auctionService";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom"; // ← 1

const ClosedAuctionsPage = () => {
  const [auctions, setAuctions] = useState<Auction[]>([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    getClosedAuctions()
      .then((data) => {
        console.log("API svar:", data);
        setAuctions(data);
      })
      .catch((err) => console.error(err)); // ← saknas
  }, []);

  // Efter useState:
  const filteredAuctions = auctions.filter(
    (
      a, // ← 2
    ) => a.title.toLowerCase().includes(search.toLowerCase()),
  );

  return (
    <div className={styles.container}>
      <h1>Avslutade Auktioner</h1>

      <input
        type="text"
        placeholder="Sök auktion..."
        value={search}
        onChange={(e) => setSearch(e.target.value)}
        className={styles.search}
      />

      <div className={styles.grid}>
        {filteredAuctions.map((auction) => (
          <Link
            key={auction.id}
            to={`/auctions/${auction.id}`}
            className={styles.card}
          >
            {auction.imageUrl && (
              <img src={auction.imageUrl} alt={auction.title} />
            )}
            <div className={styles.cardBody}>
              <h2>{auction.title}</h2>
              <p>{auction.description}</p>
              <p>Pris: {auction.price} kr</p>
            </div>
          </Link>
        ))}
      </div>
    </div>
  );
};

export default ClosedAuctionsPage;
