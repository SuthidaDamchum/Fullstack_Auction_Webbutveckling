import { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getAuctionById, updateAuction } from '../../services/auctionService';
import { getBidsByAuctionId } from '../../services/bidService';
import { useAuth } from '../../context/AuthContext';
import styles from './UpdateAuctionPage.module.css';

const UpdateAuctionPage = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const { user } = useAuth();

    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [price, setPrice] = useState(0);
    const [endDate, setEndDate] = useState('');
    const [hasBids, setHasBids] = useState(false);
    const [error, setError] = useState('');

    useEffect(() => {
        const auctionId = Number(id);

        getAuctionById(auctionId).then((data) => {
            // Kolla att det är ägarens auktion
            if (data.userId !== user?.id) {
                navigate('/auctions');
                return;
            }
            setTitle(data.title);
            setDescription(data.description);
            setPrice(data.price);
            setEndDate(data.endDate.slice(0, 16)); // format för datetime-local
        });

        getBidsByAuctionId(auctionId).then((bids) => {
            setHasBids(bids.length > 0); // ← finns det bud?
        });
    }, [id]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');
        try {
            await updateAuction(Number(id), { title, description, price, endDate });
            navigate(`/auctions/${id}`);
        } catch {
            setError('Något gick fel!');
        }
    };

    return (
        <div className={styles.container}>
            <form className={styles.form} onSubmit={handleSubmit}>
                <h2>Redigera Auktion</h2>

                {error && <p className={styles.error}>{error}</p>}

                <div className={styles.inputGroup}>
                    <label>Titel</label>
                    <input
                        type="text"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                    />
                </div>

                <div className={styles.inputGroup}>
                    <label>Beskrivning</label>
                    <textarea
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                        required
                    />
                </div>

                <div className={styles.inputGroup}>
                    <label>
                        Pris (kr) {hasBids && <span className={styles.noBidChange}>- kan inte ändras (finns bud)</span>}
                    </label>
                    <input
                        type="number"
                        value={price}
                        onChange={(e) => setPrice(Number(e.target.value))}
                        disabled={hasBids}  // ← låst om det finns bud!
                        required
                    />
                </div>

                <div className={styles.inputGroup}>
                    <label>Slutdatum</label>
                    <input
                        type="datetime-local"
                        value={endDate}
                        onChange={(e) => setEndDate(e.target.value)}
                        required
                    />
                </div>

                <div className={styles.buttons}>
                    <button type="submit" className={styles.saveBtn}>
                        Spara ändringar
                    </button>
                    <button 
                        type="button" 
                        className={styles.cancelBtn}
                        onClick={() => navigate(`/auctions/${id}`)}
                    >
                        Avbryt
                    </button>
                </div>
            </form>
        </div>
    );
};

export default UpdateAuctionPage;