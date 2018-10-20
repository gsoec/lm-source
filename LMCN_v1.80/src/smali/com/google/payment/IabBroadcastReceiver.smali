.class public Lcom/google/payment/IabBroadcastReceiver;
.super Landroid/content/BroadcastReceiver;
.source "IabBroadcastReceiver.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;
    }
.end annotation


# static fields
.field public static final ACTION:Ljava/lang/String; = "com.android.vending.billing.PURCHASES_UPDATED"


# instance fields
.field private final mListener:Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;


# direct methods
.method public constructor <init>(Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;)V
    .locals 0
    .param p1, "listener"    # Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;

    .prologue
    .line 50
    invoke-direct {p0}, Landroid/content/BroadcastReceiver;-><init>()V

    .line 51
    iput-object p1, p0, Lcom/google/payment/IabBroadcastReceiver;->mListener:Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;

    .line 52
    return-void
.end method


# virtual methods
.method public onReceive(Landroid/content/Context;Landroid/content/Intent;)V
    .locals 1
    .param p1, "context"    # Landroid/content/Context;
    .param p2, "intent"    # Landroid/content/Intent;

    .prologue
    .line 56
    iget-object v0, p0, Lcom/google/payment/IabBroadcastReceiver;->mListener:Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;

    if-eqz v0, :cond_0

    .line 57
    iget-object v0, p0, Lcom/google/payment/IabBroadcastReceiver;->mListener:Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;

    invoke-interface {v0}, Lcom/google/payment/IabBroadcastReceiver$IabBroadcastListener;->receivedBroadcast()V

    .line 59
    :cond_0
    return-void
.end method
