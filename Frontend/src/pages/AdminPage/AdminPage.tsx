import { useState, useEffect } from 'react';
import { getAllAuctions, deactivateAuction } from '../../services/auctionService';
import { getAllUsers, deactivateUser } from '../../services/userService';
import type { Auction } from '../../types/Auction';
import type { UserDTO } from '../../services/userService';
import styles from './AdminPage.module.css';

const AdminPage = () => {
    const [auctions, setAuctions] = useState<Auction[]>([]);
    const [users, setUsers] = useState<UserDTO[]>([]);
    const [activeTab, setActiveTab] = useState<'auctions' | 'users'>('auctions');

    useEffect(() => {
        getAllAuctions().then(setAuctions).catch(console.error);
        getAllUsers().then(setUsers).catch(console.error);
    }, []);

    const handleDeactivateAuction = async (id: number) => {
        try {
            await deactivateAuction(id);
            setAuctions(prev => prev.map(a =>
                a.id === id ? { ...a, isActive: false } : a
            ));
        } catch {
            alert('Kunde inte deaktivera auktion');
        }
    };

    const handleDeactivateUser = async (id: number) => {
        try {
            await deactivateUser(id);
            setUsers(prev => prev.map(u =>
                u.id === id ? { ...u, isActive: false } : u
            ));
        } catch {
            alert('Kunde inte deaktivera användare');
        }
    };

    return (
        <div className={styles.container}>
            <h1>Admin Panel</h1>

            <div className={styles.tabs}>
                <button
                    className={activeTab === 'auctions' ? styles.activeTab : styles.tab}
                    onClick={() => setActiveTab('auctions')}
                >
                    Auktioner
                </button>
                <button
                    className={activeTab === 'users' ? styles.activeTab : styles.tab}
                    onClick={() => setActiveTab('users')}
                >
                    Användare
                </button>
            </div>

            {/* AUKTIONER */}
            {activeTab === 'auctions' && (
                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Titel</th>
                            <th>Skapad av</th>
                            <th>Slutar</th>
                            <th>Status</th>
                            <th>Åtgärd</th>
                        </tr>
                    </thead>
                    <tbody>
                        {auctions.map(auction => (
                            <tr key={auction.id} className={!auction.isActive ? styles.inactiveRow : ''}>
                                <td>{auction.id}</td>
                                <td>{auction.title}</td>
                                <td>{auction.createdBy}</td>
                                <td>{new Date(auction.endDate).toLocaleDateString('sv-SE')}</td>
                                <td>
                                    <span className={auction.isActive ? styles.activeBadge : styles.inactiveBadge}>
                                        {auction.isActive ? 'Aktiv' : 'Inaktiv'}
                                    </span>
                                </td>
                                <td>
                                    {auction.isActive && (
                                        <button
                                            className={styles.deactivateBtn}
                                            onClick={() => handleDeactivateAuction(auction.id)}
                                        >
                                            Deaktivera
                                        </button>
                                    )}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}

            {/* ANVÄNDARE */}
            {activeTab === 'users' && (
                <table className={styles.table}>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Namn</th>
                            <th>Email</th>
                            <th>Roll</th>
                            <th>Status</th>
                            <th>Åtgärd</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map(user => (
                            <tr key={user.id} className={!user.isActive ? styles.inactiveRow : ''}>
                                <td>{user.id}</td>
                                <td>{user.name}</td>
                                <td>{user.email}</td>
                                <td>{user.role}</td>
                                <td>
                                    <span className={user.isActive ? styles.activeBadge : styles.inactiveBadge}>
                                        {user.isActive ? 'Aktiv' : 'Inaktiv'}
                                    </span>
                                </td>
                                <td>
                                    {user.isActive && (
                                        <button
                                            className={styles.deactivateBtn}
                                            onClick={() => handleDeactivateUser(user.id)}
                                        >
                                            Deaktivera
                                        </button>
                                    )}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
};

export default AdminPage;