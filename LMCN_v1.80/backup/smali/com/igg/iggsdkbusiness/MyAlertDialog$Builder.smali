.class public Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;
.super Landroid/app/AlertDialog$Builder;
.source "MyAlertDialog.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/igg/iggsdkbusiness/MyAlertDialog;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Builder"
.end annotation


# instance fields
.field private dialog:Lcom/igg/iggsdkbusiness/MyAlertDialog;


# direct methods
.method public constructor <init>(Landroid/content/Context;)V
    .locals 1
    .param p1, "context"    # Landroid/content/Context;

    .prologue
    .line 34
    invoke-direct {p0, p1}, Landroid/app/AlertDialog$Builder;-><init>(Landroid/content/Context;)V

    .line 36
    new-instance v0, Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-direct {v0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog;-><init>(Landroid/content/Context;)V

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->dialog:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    .line 37
    return-void
.end method


# virtual methods
.method public bridge synthetic create()Landroid/app/AlertDialog;
    .locals 1

    .prologue
    .line 29
    invoke-virtual {p0}, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->create()Lcom/igg/iggsdkbusiness/MyAlertDialog;

    move-result-object v0

    return-object v0
.end method

.method public create()Lcom/igg/iggsdkbusiness/MyAlertDialog;
    .locals 1

    .prologue
    .line 41
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->dialog:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    return-object v0
.end method

.method public bridge synthetic setIcon(I)Landroid/app/AlertDialog$Builder;
    .locals 1

    .prologue
    .line 29
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->setIcon(I)Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;

    move-result-object v0

    return-object v0
.end method

.method public setIcon(I)Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;
    .locals 1
    .param p1, "iconId"    # I

    .prologue
    .line 58
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->dialog:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->setIcon(I)V

    .line 59
    return-object p0
.end method

.method public bridge synthetic setMessage(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;
    .locals 1

    .prologue
    .line 29
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->setMessage(Ljava/lang/CharSequence;)Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;

    move-result-object v0

    return-object v0
.end method

.method public setMessage(Ljava/lang/CharSequence;)Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;
    .locals 1
    .param p1, "message"    # Ljava/lang/CharSequence;

    .prologue
    .line 46
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->dialog:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->setMessage(Ljava/lang/CharSequence;)V

    .line 47
    return-object p0
.end method

.method public bridge synthetic setTitle(Ljava/lang/CharSequence;)Landroid/app/AlertDialog$Builder;
    .locals 1

    .prologue
    .line 29
    invoke-virtual {p0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->setTitle(Ljava/lang/CharSequence;)Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;

    move-result-object v0

    return-object v0
.end method

.method public setTitle(Ljava/lang/CharSequence;)Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;
    .locals 1
    .param p1, "title"    # Ljava/lang/CharSequence;

    .prologue
    .line 52
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/MyAlertDialog$Builder;->dialog:Lcom/igg/iggsdkbusiness/MyAlertDialog;

    invoke-virtual {v0, p1}, Lcom/igg/iggsdkbusiness/MyAlertDialog;->setTitle(Ljava/lang/CharSequence;)V

    .line 53
    return-object p0
.end method
