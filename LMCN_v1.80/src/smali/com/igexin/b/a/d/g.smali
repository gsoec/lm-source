.class final Lcom/igexin/b/a/d/g;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/lang/Runnable;


# instance fields
.field final a:Ljava/util/concurrent/BlockingQueue;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/concurrent/BlockingQueue",
            "<",
            "Lcom/igexin/b/a/d/d;",
            ">;"
        }
    .end annotation
.end field

.field b:Lcom/igexin/b/a/d/d;

.field c:Lcom/igexin/b/a/d/d;

.field volatile d:I

.field final synthetic e:Lcom/igexin/b/a/d/f;


# direct methods
.method public constructor <init>(Lcom/igexin/b/a/d/f;Lcom/igexin/b/a/d/d;)V
    .locals 1

    iput-object p1, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p2, p0, Lcom/igexin/b/a/d/g;->b:Lcom/igexin/b/a/d/d;

    new-instance v0, Ljava/util/concurrent/LinkedBlockingQueue;

    invoke-direct {v0}, Ljava/util/concurrent/LinkedBlockingQueue;-><init>()V

    iput-object v0, p0, Lcom/igexin/b/a/d/g;->a:Ljava/util/concurrent/BlockingQueue;

    return-void
.end method


# virtual methods
.method public final a()V
    .locals 1

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->a:Ljava/util/concurrent/BlockingQueue;

    invoke-interface {v0}, Ljava/util/concurrent/BlockingQueue;->clear()V

    const/4 v0, 0x0

    iput-object v0, p0, Lcom/igexin/b/a/d/g;->c:Lcom/igexin/b/a/d/d;

    return-void
.end method

.method public final a(Lcom/igexin/b/a/d/d;)V
    .locals 10

    const/4 v3, 0x0

    const/4 v0, 0x1

    const/4 v2, 0x0

    const-wide/16 v8, 0x0

    iget v1, p0, Lcom/igexin/b/a/d/g;->d:I

    if-nez v1, :cond_0

    iget v1, p1, Lcom/igexin/b/a/d/d;->z:I

    iput v1, p0, Lcom/igexin/b/a/d/g;->d:I

    :cond_0
    move v1, v0

    :cond_1
    :goto_0
    if-eqz v1, :cond_7

    :try_start_0
    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->a_()V

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->t()V

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->v()V
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v0, :cond_2

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->c()V

    :cond_2
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "TaskService|Worker|runTask = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|isDone = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->k:Z

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|isCycle = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|doTime = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    invoke-virtual {v0, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_3

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->o:Z

    if-eqz v0, :cond_3

    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    cmp-long v0, v4, v8

    if-nez v0, :cond_1

    :cond_3
    move v1, v2

    move-object p1, v3

    goto :goto_0

    :catch_0
    move-exception v0

    :try_start_1
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService"

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v5

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    const/4 v4, 0x1

    iput-boolean v4, p1, Lcom/igexin/b/a/d/d;->t:Z

    iput-object v0, p1, Lcom/igexin/b/a/d/d;->B:Ljava/lang/Exception;

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->w()V

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->p()V

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    iget-object v0, v0, Lcom/igexin/b/a/d/f;->i:Lcom/igexin/b/a/d/e;

    invoke-virtual {v0, p1}, Lcom/igexin/b/a/d/e;->a(Ljava/lang/Object;)Z

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    iget-object v0, v0, Lcom/igexin/b/a/d/f;->i:Lcom/igexin/b/a/d/e;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/e;->f()V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v0, :cond_4

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->c()V

    :cond_4
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "TaskService|Worker|runTask = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|isDone = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->k:Z

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|isCycle = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v4, "|doTime = "

    invoke-virtual {v0, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    invoke-virtual {v0, v4, v5}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v0, :cond_3

    iget-boolean v0, p1, Lcom/igexin/b/a/d/d;->o:Z

    if-eqz v0, :cond_3

    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    cmp-long v0, v4, v8

    if-eqz v0, :cond_3

    goto/16 :goto_0

    :catchall_0
    move-exception v0

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->t:Z

    if-nez v4, :cond_5

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->c()V

    :cond_5
    new-instance v4, Ljava/lang/StringBuilder;

    invoke-direct {v4}, Ljava/lang/StringBuilder;-><init>()V

    const-string v5, "TaskService|Worker|runTask = "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "|isDone = "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-boolean v5, p1, Lcom/igexin/b/a/d/d;->k:Z

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "|isCycle = "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-boolean v5, p1, Lcom/igexin/b/a/d/d;->o:Z

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Z)Ljava/lang/StringBuilder;

    move-result-object v4

    const-string v5, "|doTime = "

    invoke-virtual {v4, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v4

    iget-wide v6, p1, Lcom/igexin/b/a/d/d;->u:J

    invoke-virtual {v4, v6, v7}, Ljava/lang/StringBuilder;->append(J)Ljava/lang/StringBuilder;

    move-result-object v4

    invoke-virtual {v4}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v4

    invoke-static {v4}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->k:Z

    if-nez v4, :cond_6

    iget-boolean v4, p1, Lcom/igexin/b/a/d/d;->o:Z

    if-eqz v4, :cond_6

    iget-wide v4, p1, Lcom/igexin/b/a/d/d;->u:J

    cmp-long v4, v4, v8

    if-nez v4, :cond_1

    :cond_6
    throw v0

    :cond_7
    return-void
.end method

.method final b()Lcom/igexin/b/a/d/d;
    .locals 5

    const/4 v1, 0x0

    :cond_0
    :goto_0
    iget v0, p0, Lcom/igexin/b/a/d/g;->d:I

    if-eqz v0, :cond_3

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/d/g;->a:Ljava/util/concurrent/BlockingQueue;

    iget-object v2, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    iget-wide v2, v2, Lcom/igexin/b/a/d/f;->e:J

    sget-object v4, Ljava/util/concurrent/TimeUnit;->NANOSECONDS:Ljava/util/concurrent/TimeUnit;

    invoke-interface {v0, v2, v3, v4}, Ljava/util/concurrent/BlockingQueue;->poll(JLjava/util/concurrent/TimeUnit;)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/b/a/d/d;

    if-eqz v0, :cond_1

    :goto_1
    return-object v0

    :cond_1
    iget-object v0, p0, Lcom/igexin/b/a/d/g;->a:Ljava/util/concurrent/BlockingQueue;

    invoke-interface {v0}, Ljava/util/concurrent/BlockingQueue;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    iget-object v2, v0, Lcom/igexin/b/a/d/f;->c:Ljava/util/concurrent/locks/ReentrantLock;

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->lock()V
    :try_end_0
    .catch Ljava/lang/InterruptedException; {:try_start_0 .. :try_end_0} :catch_0

    :try_start_1
    iget-object v0, p0, Lcom/igexin/b/a/d/g;->a:Ljava/util/concurrent/BlockingQueue;

    invoke-interface {v0}, Ljava/util/concurrent/BlockingQueue;->isEmpty()Z
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    move-result v0

    if-nez v0, :cond_2

    :try_start_2
    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V
    :try_end_2
    .catch Ljava/lang/InterruptedException; {:try_start_2 .. :try_end_2} :catch_0

    goto :goto_0

    :catch_0
    move-exception v0

    goto :goto_0

    :cond_2
    :try_start_3
    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    iget-object v0, v0, Lcom/igexin/b/a/d/f;->b:Ljava/util/HashMap;

    iget v3, p0, Lcom/igexin/b/a/d/g;->d:I

    invoke-static {v3}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    invoke-virtual {v0, v3}, Ljava/util/HashMap;->remove(Ljava/lang/Object;)Ljava/lang/Object;

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->c:Lcom/igexin/b/a/d/d;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/d;->e()V

    const/4 v0, 0x0

    iput v0, p0, Lcom/igexin/b/a/d/g;->d:I
    :try_end_3
    .catchall {:try_start_3 .. :try_end_3} :catchall_0

    :try_start_4
    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    move-object v0, v1

    goto :goto_1

    :catchall_0
    move-exception v0

    invoke-virtual {v2}, Ljava/util/concurrent/locks/ReentrantLock;->unlock()V

    throw v0
    :try_end_4
    .catch Ljava/lang/InterruptedException; {:try_start_4 .. :try_end_4} :catch_0

    :cond_3
    move-object v0, v1

    goto :goto_1
.end method

.method public final run()V
    .locals 4

    const/4 v1, 0x0

    const/4 v0, 0x1

    :cond_0
    :goto_0
    if-eqz v0, :cond_4

    :try_start_0
    iget-object v0, p0, Lcom/igexin/b/a/d/g;->b:Lcom/igexin/b/a/d/d;

    const/4 v2, 0x0

    iput-object v2, p0, Lcom/igexin/b/a/d/g;->b:Lcom/igexin/b/a/d/d;

    :goto_1
    if-nez v0, :cond_1

    invoke-virtual {p0}, Lcom/igexin/b/a/d/g;->b()Lcom/igexin/b/a/d/d;

    move-result-object v0

    if-nez v0, :cond_1

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    invoke-virtual {v0}, Lcom/igexin/b/a/d/f;->a()Lcom/igexin/b/a/d/d;

    move-result-object v0

    if-eqz v0, :cond_2

    :cond_1
    const/4 v2, 0x0

    iput-object v2, p0, Lcom/igexin/b/a/d/g;->c:Lcom/igexin/b/a/d/d;

    invoke-virtual {p0, v0}, Lcom/igexin/b/a/d/g;->a(Lcom/igexin/b/a/d/d;)V

    iput-object v0, p0, Lcom/igexin/b/a/d/g;->c:Lcom/igexin/b/a/d/d;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0
    .catchall {:try_start_0 .. :try_end_0} :catchall_0

    move-object v0, v1

    goto :goto_1

    :cond_2
    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    invoke-virtual {v0, p0}, Lcom/igexin/b/a/d/f;->a(Lcom/igexin/b/a/d/g;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/b/a/d/g;->a()V

    goto :goto_0

    :catch_0
    move-exception v0

    :try_start_1
    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "TaskService|Worker|run()|error"

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v2

    invoke-virtual {v0}, Ljava/lang/Exception;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    invoke-static {v0}, Lcom/igexin/b/a/c/a;->b(Ljava/lang/String;)V
    :try_end_1
    .catchall {:try_start_1 .. :try_end_1} :catchall_0

    iget-object v0, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    invoke-virtual {v0, p0}, Lcom/igexin/b/a/d/f;->a(Lcom/igexin/b/a/d/g;)Z

    move-result v0

    if-nez v0, :cond_0

    invoke-virtual {p0}, Lcom/igexin/b/a/d/g;->a()V

    goto :goto_0

    :catchall_0
    move-exception v0

    iget-object v1, p0, Lcom/igexin/b/a/d/g;->e:Lcom/igexin/b/a/d/f;

    invoke-virtual {v1, p0}, Lcom/igexin/b/a/d/f;->a(Lcom/igexin/b/a/d/g;)Z

    move-result v1

    if-nez v1, :cond_3

    invoke-virtual {p0}, Lcom/igexin/b/a/d/g;->a()V

    :cond_3
    throw v0

    :cond_4
    return-void
.end method
